#include "Animation.h"

Animation::Animation(IntRect* rect, int framesNumb) {
	bounds = rect;
	frames = framesNumb;
	resetValue = rect->left;
}

void Animation::changeFrame() {
	if (clock.getElapsedTime().asSeconds() >= 0.1f) { // �������� ���������� ���
		if (bounds->left >= (resetValue + 15 * (frames - 1))) { // �� ������� ������ ����������� ���
			bounds->left = resetValue;
		}
		else {
			bounds->left += 15; // ����������� ������
		}
		clock.restart();
	}
}

IntRect Animation::getBounds() { return *bounds; }
