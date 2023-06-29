#pragma once
#include "Player.h"
#include "Way.h"

class Monster : public Player {
private:
	int locChankX;
	int locChankY;
	Way moving;

	bool scattering;
	bool outCell;
	bool choice;
	int harmless;

public:
	Monster(int tilePosX, int tilePosY, int destinationX, int destinationY);

	void setLocation(int x, int y);
	int getLocX();
	int getLocY();

	void setWay(Way dir);
	Way getWay();
	void move();

	bool isScattering();
	void setScattering(bool s);
	void setHarmless(bool f);
	bool isHarmless();

	void tp(int x, int y);
	bool outsideCell();

	bool shouldChoice();
	void setChoice(bool d);
};

