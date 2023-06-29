#pragma once
#include "SFML/Graphics.hpp"
#include "GameCondition.h"
#include <stack>
using namespace sf;
using namespace std;

class Condition {
private:
	stack<GameCondition*> conditions;
public:
	void addCondition(GameCondition* cond);
	void cycle();
	void render(RenderWindow* window);
	void keyPress(int key);
	void keyUnPress(int key);
};