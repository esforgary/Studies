#include "PacMan.h"

// ��������� ����� PacMan
PacMan::PacMan() : Player(13, 26) { eatDots = 0; }

// �������� �� ������������ 
void PacMan::queueWay(Way w) {
	if (!way.empty()) {
		if (w == -way.front()) {
			queue<Way> clear;
			swap(way, clear);
		}
	}
	if (way.size() < 2) {
		way.push(w);
	}
}

// �������� ����������� PacMan 
void PacMan::move() {
	if (!way.empty()) {
		switch (way.front()) {
		case Way::Up:Player::move(0, -0.4f); break;
		case Way::Down:Player::move(0, 0.4f); break;
		case Way::Left:Player::move(-0.4f, 0); break;
		case Way::Right:Player::move(0.4f, 0); break;
		}
	}
}

// ������� ��������� PacMan
void PacMan::stop() {
	if (way.size() > 1) {
		if ((int)(screenPosX + 8) % 16 == 0 && (int)(screenPosY + 8) % 16 == 0) {
			switch (way.front()) {
			case Way::Up:way.pop(); break;
			case Way::Down:way.pop(); break;
			case Way::Left:way.pop(); break;
			case Way::Right: way.pop(); break;
			}
		}
	}
}

// ������� �� ��������� �������� PacMan 
queue<Way> PacMan::getWay() { return way; }
// PacMan ���� �����
void PacMan::eatDot() { eatDots++; }
int PacMan::getDotsEaten() { return eatDots; }
// PacMan ���� 
void PacMan::setDead(bool d) { dead = d; }
bool PacMan::isDead() { return dead; }