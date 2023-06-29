#pragma once
#include "SFML/Graphics.hpp"
#include "Condition.h"

class Motor {
private:
	static RenderWindow window;
	static Condition gamestates;
public:
	static void initialization();
	static bool isRunning();
	static void events();
	static void render();
};