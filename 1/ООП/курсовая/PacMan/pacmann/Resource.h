#pragma once
#include "SFML/Graphics.hpp"
#include "Animation.h"
#include <iostream>
#include "Way.h"
#include <map>
using namespace std;
using namespace sf;

class Resource {
private:
	static Texture Items;
	static Texture Map;

	static map<int, Sprite*> sprites;
	static map<int, Animation> animations;

	static void loadSprite(int value, int rect1, int rect2, int animationframes);

	static const int PacManDown;
	static const int PacManLeft;
	static const int PacManRight;

	static const int M1Down;
	static const int M1Left;
	static const int M1Right;

	static const int M2Down;
	static const int M2Left;
	static const int M2Right;

	static const int M3Down;
	static const int M3Left;
	static const int M3Right;

	static const int M4Down;
	static const int M4Left;
	static const int M4Right;

public:
	static void load();
	static Sprite* get(int value, bool animated, Way facing);
	static Sprite* MapParts[];
	static const int PacManUp;
	static const int DeadPacMan;
	static const int M1Up;
	static const int M2Up;
	static const int M3Up;
	static const int M4Up;
	static const int HarmlessMonster;

};