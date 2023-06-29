#pragma once
#include "PacMan.h"
#include "Monster.h"

class Map {
public:
	static const int SizeX = 28;
	static const int SizeY = 36;

	Map();
	int getChank(int x, int y);
	bool BlockChankPlayer(int x, int y);
	bool isCross(int x, int y);
	void takeDot(PacMan* pacman, Monster* monster1, Monster* monster2, Monster* monster3, Monster* monster4);

private:
	int chank[SizeX][SizeY];
};