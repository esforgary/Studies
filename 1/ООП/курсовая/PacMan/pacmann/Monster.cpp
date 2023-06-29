#include "Monster.h"

Monster::Monster(int chankPosX, int chankPosY, int locationX, int locationY) : Player(chankPosX, chankPosY) {
	setLocation(locationX, locationY);
	setWay(Way::Unset);
	scattering = true;
	outCell = false;
	choice = true;
	harmless = false;
}

// ����������� �������
void Monster::setLocation(int x, int y) { locChankX = x; locChankY = y; }
int Monster::getLocX() { return locChankX; }
int Monster::getLocY() { return locChankY; }

// ��������
void Monster::setWay(Way w) { moving = w; }
Way Monster::getWay() { return moving; }

// �������� �������� ��������
void Monster::move() {
	switch (moving) {
	case Way::Up:Player::move(0, -0.2f); break;
	case Way::Down:Player::move(0, 0.2f); break;
	case Way::Left:Player::move(-0.2f, 0); break;
	case Way::Right:Player::move(0.2f, 0); break;
	}
}

// ������������ ��������
bool Monster::isScattering() { return scattering; }
void Monster::setScattering(bool s) { scattering = s; }

// ������� � �������
bool Monster::outsideCell() { return outCell; }

// �������� ������� ��������
bool Monster::shouldChoice() { return choice; }
void Monster::setChoice(bool d) { choice = d; }

// ������������ ��������
void Monster::tp(int x, int y) {
	Player::tp(x, y);
	outCell = true;
}

// ������� ��������� ������� 
void Monster::setHarmless(bool f) {
	if (f) { harmless = 2500; }
	else { harmless = 0; }
}
// ������������ ������� 
bool Monster::isHarmless() {
	if (harmless > 0) harmless--; {
		return harmless > 0;
	}
}