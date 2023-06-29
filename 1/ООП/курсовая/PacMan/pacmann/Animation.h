#pragma once
#include "SFML/Graphics.hpp"
using namespace sf;

class Animation {
private:
	IntRect* bounds;
	Clock clock;
	int frames;
	int resetValue;
public:
	Animation(IntRect* rect, int framesNumber);
	void changeFrame();
	IntRect getBounds();
};