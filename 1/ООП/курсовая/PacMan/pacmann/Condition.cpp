#include "Condition.h" 
// методы для коректной работы и рендеринга окна
void Condition::addCondition(GameCondition* cond) {
	conditions.push(cond);
	conditions.top()->initialization();
}

void Condition::cycle() {
	conditions.top()->cycle();
}

void Condition::render(RenderWindow* window) {
	conditions.top()->render(window);
}

void Condition::keyPress(int key) {
	conditions.top()->keyPress(key);
}

void Condition::keyUnPress(int key) {
	conditions.top()->keyUnPress(key);
}