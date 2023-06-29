#include "Player.h"
#include <cmath>

// �������������� ������� 
Player::Player(int chankPosX, int chankPosY) {
	chankX = chankPosX;
	chankY = chankPosY;
	screenPosX = chankPosX * 16.0f + 8.0f + 8.0f;
	screenPosY = chankPosY * 16.0f + 8.0f;
}

float Player::getScreenPosX() { return screenPosX; }
float Player::getScreenPosY() { return screenPosY; }
int Player::getChankX() { return chankX; }
int Player::getChankY() { return chankY; }

// ������������� ����������� �������
void Player::move(float x, float y) {
	screenPosX += x;
	screenPosY += y;

	if ((int)(screenPosX + 8) % 16 == 0 && (int)(screenPosY + 8) % 16 == 0) {
		chankX = (int)round((screenPosX - 8) / 16);
		chankY = (int)round((screenPosY - 8) / 16);
	}
}

// ������������� ������������ �������
void Player::tp(int x, int y) {
	chankX = x;
	chankY = y;
	screenPosX = x * 16.0f + 8.0f;
	screenPosY = y * 16.0f + 8.0f;
}