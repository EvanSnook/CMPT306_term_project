using UnityEngine;
using System.Collections;

public interface IMovable {
	void MoveUp(float velocity);
	void MoveDown(float velocity);
	void MoveLeft(float velocity);
	void MoveRight(float velocity);
}
