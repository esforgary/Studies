#pragma once

class Player {
protected:
	float screenPosX;
	float screenPosY;
	int chankX;
	int chankY;

public:
	Player(int chankPosX, int chankPosY);

	float getScreenPosX();
	float getScreenPosY();
	int getChankX();
	int getChankY();

	void move(float x, float y);
	void tp(int x, int y);
};