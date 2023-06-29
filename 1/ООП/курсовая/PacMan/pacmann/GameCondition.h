#pragma once
#include "SFML/Graphics.hpp"
using namespace sf;

class GameCondition {
public:
	virtual void initialization() {}
	virtual void cycle() = 0;
	virtual void render(RenderWindow* window) = 0;
	virtual void keyPress(int key) = 0;
	virtual void keyUnPress(int key) = 0;
};