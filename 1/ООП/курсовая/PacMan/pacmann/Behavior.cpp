#include "SFML/Graphics.hpp"
#include "Behavior.h"
#include "Resource.h" 
#include "Monster.h" 
#include "PacMan.h"
#include "Way.h" 
#include <cstdlib>
#include <random>
#include <cmath>

// расстановка игроков и выбор их направления по умолчанию
void Behavior::initialization() {
	srand(time(NULL));
	waitTime = 0;

	map = new Map();
	pacman = new PacMan();
	M1 = new Monster(13, 14, 10, 32);
	M2 = new Monster(13, 17, 26, 4);
	M3 = new Monster(11, 17, 23, 32);
	M4 = new Monster(15, 17, 32, 4);
	M1->tp(13, 14);
}

// отображение игроков на карте
void Behavior::render(RenderWindow* window) {
	Sprite pacmanSprite;
	Sprite M1Sprite;
	Sprite M2Sprite;
	Sprite M3Sprite;
	Sprite M4Sprite;

	if (pacman->getWay().empty()) { pacmanSprite = *Resource::get(Resource::PacManUp, false, Way::Unset); }
	else { pacmanSprite = *Resource::get(Resource::PacManUp, true, pacman->getWay().front()); }

	if (pacman->isDead()) { pacmanSprite = *Resource::get(Resource::DeadPacMan, true, Way::Unset); }

	if (!M1->isHarmless()) { M1Sprite = *Resource::get(Resource::M1Up, M1->outsideCell(), M1->getWay()); }
	else { M1Sprite = *Resource::get(Resource::HarmlessMonster, M1->outsideCell(), M1->getWay()); }

	if (!M2->isHarmless()) { M2Sprite = *Resource::get(Resource::M2Up, M2->outsideCell(), M2->getWay()); }
	else { M2Sprite = *Resource::get(Resource::HarmlessMonster, M2->outsideCell(), M2->getWay()); }

	if (!M3->isHarmless()) { M3Sprite = *Resource::get(Resource::M3Up, M3->outsideCell(), M3->getWay()); }
	else { M3Sprite = *Resource::get(Resource::HarmlessMonster, M3->outsideCell(), M3->getWay()); }

	if (!M4->isHarmless()) { M4Sprite = *Resource::get(Resource::M4Up, M4->outsideCell(), M4->getWay()); }
	else { M4Sprite = *Resource::get(Resource::HarmlessMonster, M4->outsideCell(), M4->getWay()); }

	pacmanSprite.setPosition(pacman->getScreenPosX(), pacman->getScreenPosY());
	M1Sprite.setPosition(M1->getScreenPosX(), M1->getScreenPosY());
	M2Sprite.setPosition(M2->getScreenPosX(), M2->getScreenPosY());
	M3Sprite.setPosition(M3->getScreenPosX(), M3->getScreenPosY());
	M4Sprite.setPosition(M4->getScreenPosX(), M4->getScreenPosY());

	for (int i = 0; i < Map::SizeX; i++) {
		for (int j = 0; j < Map::SizeY; j++) {
			Resource::MapParts[map->getChank(i, j)]->setPosition(i * 16.0f, j * 16.0f);
			window->draw(*Resource::MapParts[map->getChank(i, j)]);
		}
	}

	window->draw(pacmanSprite);
	window->draw(M1Sprite);
	window->draw(M2Sprite);
	window->draw(M3Sprite);
	window->draw(M4Sprite);
}


void Behavior::cycle() {
	// когда PacMan двигается а когда стоит
	if (pacmanCanMove() && !pacman->isDead()) { pacman->move(); }
	else { pacman->stop(); }

	if (map->isCross(pacman->getChankX(), pacman->getChankY())) { pacman->stop(); }

	map->takeDot(pacman, M1, M2, M3, M4);
	// поведение каждого монстра 
	if (!pacman->getWay().empty()) {
		if (!M1->isHarmless()) {
			M1->setLocation(pacman->getChankX(), pacman->getChankY());
		}

		if (!M2->isHarmless()) {
			switch (pacman->getWay().front()) {
			case Way::Up:M2->setLocation(pacman->getChankX(), pacman->getChankY() - 4); break;
			case Way::Down:M2->setLocation(pacman->getChankX(), pacman->getChankY() + 4); break;
			case Way::Left:M2->setLocation(pacman->getChankX() - 4, pacman->getChankY()); break;
			case Way::Right:M2->setLocation(pacman->getChankX() + 4, pacman->getChankY()); break;
			}
		}

		if (!M3->isHarmless()) {
			M3->setLocation(pacman->getChankX() + (M2->getChankX() - pacman->getChankX()), pacman->getChankY() + (M2->getChankY() - pacman->getChankY()));
		}

		if (!M4->isHarmless()) {
			if (sqrt(pow((M4->getChankX() - (pacman->getChankX())), 2) + pow((M4->getChankY() - (pacman->getChankY())), 2)) < 9) {
				M4->setLocation(pacman->getChankX(), pacman->getChankY());
			}
			else {
				M4->setLocation(1, 32);
			}
		}
	}

	handleMonsterMovement(M1);
	handleMonsterMovement(M2);
	handleMonsterMovement(M3);
	handleMonsterMovement(M4);

	if (pacman->getDotsEaten() == 5) {
		M2->tp(13, 14);
	}
	if (pacman->getDotsEaten() == 50) {
		M3->tp(13, 14);
	}
	if (pacman->getDotsEaten() == 100) {
		M4->tp(13, 14);
	}
	tpTunnels(pacman);
	tpTunnels(M1);
	tpTunnels(M2);
	tpTunnels(M3);
	tpTunnels(M4);

	handleMonsterFrightened(M1);
	handleMonsterFrightened(M2);
	handleMonsterFrightened(M3);
	handleMonsterFrightened(M4);

	if (pacman->getDotsEaten() == 240) {
		M1->tp(-2, -2);
		M2->tp(-2, -2);
		M3->tp(-2, -2);
		M4->tp(-2, -2);
		waitTime++;
	}

	if (pacman->isDead())
		waitTime++;

	if (waitTime == 200) {
		if (pacman->isDead()) {
			if (M1->outsideCell()) M1->tp(13, 14);
			if (M2->outsideCell()) M2->tp(13, 14);
			if (M3->outsideCell()) M3->tp(13, 14);
			if (M4->outsideCell()) M4->tp(13, 14);
			pacman->tp(13, 26);
			pacman->setDead(false);
			waitTime = 0;
		}
		else {
			Behavior::initialization();
			waitTime = 0;
		}
	}
}


// способ управления PacMan
void Behavior::keyPress(int key) {
	switch (key) {
	case Keyboard::W:pacman->queueWay(Way::Up); break;
	case Keyboard::Up:pacman->queueWay(Way::Up); break;
	case Keyboard::S:pacman->queueWay(Way::Down); break;
	case Keyboard::Down:pacman->queueWay(Way::Down); break;
	case Keyboard::A:pacman->queueWay(Way::Left); break;
	case Keyboard::Left:pacman->queueWay(Way::Left); break;
	case Keyboard::D:pacman->queueWay(Way::Right); break;
	case Keyboard::Right:pacman->queueWay(Way::Right); break;
	}
}

// отжатие кнопок
void Behavior::keyUnPress(int key) {}

// осуществление движения PacMan по карте 
bool Behavior::pacmanCanMove() {
	if (!pacman->getWay().empty()) {
		switch (pacman->getWay().front()) {
		case Way::Up:return !map->BlockChankPlayer(pacman->getChankX(), pacman->getChankY() - 1); break;
		case Way::Down:return !map->BlockChankPlayer(pacman->getChankX(), pacman->getChankY() + 1); break;
		case Way::Left:return !map->BlockChankPlayer(pacman->getChankX() - 1, pacman->getChankY());	break;
		case Way::Right:return !map->BlockChankPlayer(pacman->getChankX() + 1, pacman->getChankY()); break;
		}
	}
	return true;
}

// движение монстров по карте
bool Behavior::monsterCanMove(Monster* monster) {
	switch (monster->getWay()) {
	case Way::Up:return !map->BlockChankPlayer(monster->getChankX(), monster->getChankY() - 1); break;
	case Way::Down:return !map->BlockChankPlayer(monster->getChankX(), monster->getChankY() + 1); break;
	case Way::Left:return !map->BlockChankPlayer(monster->getChankX() - 1, monster->getChankY()); break;
	case Way::Right:return !map->BlockChankPlayer(monster->getChankX() + 1, monster->getChankY()); break;
	default:return false;
	}
}

// осуществление движения мостров (искуственный интелект)
void Behavior::handleMonsterMovement(Monster* monster) {
	if (monster->isHarmless()) {
		if (monster->getChankX() == monster->getLocX() && monster->getChankY() == monster->getLocY()) {
			monster->setHarmless(false);
		}
	}

	if (map->isCross(monster->getChankX(), monster->getChankY())) {
		if (monster->shouldChoice()) {

			float dRight = calcDist(monster, 1, 0);
			float dLeft = calcDist(monster, -1, 0);
			float dUp = calcDist(monster, 0, -1);
			float dDown = calcDist(monster, 0, 1);


			if (dRight < dLeft && dRight < dUp && dRight < dDown) {
				monster->setWay(Way::Right);
			}
			else if (dLeft < dRight && dLeft < dUp && dLeft < dDown) {
				monster->setWay(Way::Left);
			}
			else if (dUp < dLeft && dUp < dRight && dUp < dDown) {
				monster->setWay(Way::Up);
			}
			else if (dDown < dLeft && dDown < dUp && dDown < dRight) {
				monster->setWay(Way::Down);
			}
		}
		monster->setChoice(false);
	}
	else {
		monster->setChoice(true);
	}
	if (monsterCanMove(monster) && monster->outsideCell()) {
		monster->move();
	}
	else {
		monster->setChoice(true);
	}
}

// дистанция на которой монстры замечабт на PacMan
float Behavior::calcDist(Monster* monster, int addX, int addY) {
	float distance = 1000000.0f;
	if (!map->BlockChankPlayer(monster->getChankX() + addX, monster->getChankY() + addY)) {
		distance = (float)sqrt(pow((monster->getLocX() - (monster->getChankX() + addX)), 2) + pow((monster->getLocY() - (monster->getChankY() + addY)), 2));
	}
	return distance;
}

// поедание замороженного монстра 
void Behavior::handleMonsterFrightened(Monster* monster) {
	if (pacman->getChankX() == monster->getChankX() && pacman->getChankY() == monster->getChankY()) {
		if (monster->isHarmless()) {
			monster->tp(13, 14);
			monster->setHarmless(false);
		}
		else {
			pacman->setDead(true);
			M1->tp(-2, -2);
			M2->tp(-2, -2);
			M3->tp(-2, -2);
			M4->tp(-2, -2);
		}
	}
}

// проход через тунель
void Behavior::tpTunnels(Player* player) {
	if (player->getChankX() == 0 && player->getChankY() == 17) {
		player->tp(26, 17);
	}
	else if (player->getChankX() == 27 && player->getChankY() == 17) {
		player->tp(1, 17);
	}
}