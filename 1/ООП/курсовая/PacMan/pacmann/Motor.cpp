#include "Behavior.h"
#include "Resource.h" 
#include "Motor.h" 

RenderWindow Motor::window;
Condition Motor::gamestates;

// �������� ����
bool Motor::isRunning() { return window.isOpen(); }

// �������� ���� 
void Motor::initialization() {
	Resource::load();
	window.create(VideoMode(448, 586), "PacMan", Style::Close | Style::Titlebar);
	gamestates.addCondition(new Behavior);
	Image icon;
	icon.loadFromFile("img/icon.png");
	window.setIcon(32, 32, icon.getPixelsPtr());
}

// ������������ ����
void Motor::render() {
	window.clear(Color::Black);
	gamestates.render(&window);
	window.display();
}

// �������������� � ����� 
void Motor::events() {
	Event event;
	while (window.pollEvent(event)) {
		switch (event.type) {
		case Event::Closed:window.close(); break;
		case Event::KeyPressed:gamestates.keyPress(event.key.code);	break;
		case Event::KeyReleased:gamestates.keyUnPress(event.key.code); break;
		}
	}
	gamestates.cycle();
}