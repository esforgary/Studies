#pragma once
#include "Player.h"
#include "Way.h"
#include <queue>
using namespace std;

class PacMan : public Player {
private:
	queue<Way> way;
	int eatDots;
	bool dead;
public:
	PacMan();

	queue<Way> getWay();
	void queueWay(Way dir);
	void move();
	void stop();

	void eatDot();
	int getDotsEaten();

	void setDead(bool d);
	bool isDead();
};