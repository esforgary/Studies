#include "Resource.h"

map<int, Sprite*> Resource::sprites;
map<int, Animation> Resource::animations;

Texture Resource::Items;
Texture Resource::Map;

Sprite* Resource::MapParts[32];
// анимации PacMan и монстров
const int Resource::PacManUp = 0;
const int Resource::PacManDown = 1;
const int Resource::PacManLeft = 2;
const int Resource::PacManRight = 3;

const int Resource::M1Up = 4;
const int Resource::M1Down = 5;
const int Resource::M1Left = 6;
const int Resource::M1Right = 7;

const int Resource::M2Up = 8;
const int Resource::M2Down = 9;
const int Resource::M2Left = 10;
const int Resource::M2Right = 11;

const int Resource::M3Up = 12;
const int Resource::M3Down = 13;
const int Resource::M3Left = 14;
const int Resource::M3Right = 15;

const int Resource::M4Up = 16;
const int Resource::M4Down = 17;
const int Resource::M4Left = 18;
const int Resource::M4Right = 19;

const int Resource::HarmlessMonster = 20;
const int Resource::DeadPacMan = 21;

// загрузка текстур для анимаций игроков
void Resource::load() {
	Map.loadFromFile("img/map.png");

	int index = 0;
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 4; j++) {
			MapParts[index] = new Sprite(Map, IntRect(i * 8, j * 8, 8, 8));
			MapParts[index]->setScale(2.0f, 2.0f);
			index++;
		}
	}

	Items.loadFromFile("img/things.png");

	loadSprite(Resource::PacManUp, 0, 0, 3);
	loadSprite(Resource::PacManDown, 45, 0, 3);
	loadSprite(Resource::PacManLeft, 90, 0, 3);
	loadSprite(Resource::PacManRight, 135, 0, 3);
	loadSprite(Resource::DeadPacMan, 0, 75, 12);

	loadSprite(Resource::M1Up, 0, 15, 2);
	loadSprite(Resource::M1Down, 30, 15, 2);
	loadSprite(Resource::M1Left, 60, 15, 2);
	loadSprite(Resource::M1Right, 90, 15, 2);

	loadSprite(Resource::M2Up, 0, 30, 2);
	loadSprite(Resource::M2Down, 30, 30, 2);
	loadSprite(Resource::M2Left, 60, 30, 2);
	loadSprite(Resource::M2Right, 90, 30, 2);

	loadSprite(Resource::M3Up, 0, 45, 2);
	loadSprite(Resource::M3Down, 30, 45, 2);
	loadSprite(Resource::M3Left, 60, 45, 2);
	loadSprite(Resource::M3Right, 90, 45, 2);

	loadSprite(Resource::M4Up, 0, 60, 2);
	loadSprite(Resource::M4Down, 30, 60, 2);
	loadSprite(Resource::M4Left, 60, 60, 2);
	loadSprite(Resource::M4Right, 90, 60, 2);

	loadSprite(Resource::HarmlessMonster, 120, 15, 2);
}

// смена кадров
Sprite* Resource::get(int value, bool animated, Way facing) {
	if (value != Resource::HarmlessMonster) {
		switch (facing) {
		case Way::Down: value += 1; break;
		case Way::Left: value += 2; break;
		case Way::Right:value += 3; break;
		}
	}

	if (animated) {
		animations.at(value).changeFrame();
		sprites.at(value)->setTextureRect(animations.at(value).getBounds());
	}
	return sprites.at(value);
}

// загрузка спрайтов 
void Resource::loadSprite(int value, int rect1, int rect2, int animationframes) {
	IntRect* rect = new IntRect(rect1, rect2, 15, 15);
	Sprite* sprite = new Sprite(Items, *rect);
	sprite->setScale(2.0f, 2.0f);
	sprite->setOrigin(7.5f, 7.5f);
	sprites.insert(pair<int, Sprite*>(value, sprite));
	animations.insert(pair<int, Animation>(value, Animation(rect, animationframes)));
}