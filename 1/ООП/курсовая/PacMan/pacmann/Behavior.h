#pragma once
#include "GameCondition.h" 
#include "Monster.h"
#include "Player.h"
#include "PacMan.h"
#include "map.h"
using namespace sf;

class Behavior : public GameCondition {
private:
	Map* map;
	PacMan* pacman;
	Monster* M1;
	Monster* M2;
	Monster* M3;
	Monster* M4;
	int waitTime;

	void tpTunnels(Player* player);
	bool pacmanCanMove();
	bool monsterCanMove(Monster* monster);
	void handleMonsterMovement(Monster* monster);
	void handleMonsterFrightened(Monster* monster);
	float calcDist(Monster* monster, int addX, int addY);
public:
	void initialization();
	void cycle();
	void render(RenderWindow* window);
	void keyPress(int key);
	void keyUnPress(int key);
};

