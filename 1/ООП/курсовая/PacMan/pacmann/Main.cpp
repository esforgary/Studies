#include "Motor.h" 

int main() {
	Motor::initialization();

	while (Motor::isRunning()) {
		Motor::events();
		Motor::render();
	}

	system("pause");
	return 0;
}