﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	[ReadOnly] public NewPlayer player;
    public GoalLight goalLight;
    public GridCube goalPost;
	public Color gridColor;

    private CubeEffectCircle poleEffect;

	public void SetupGoal(NewPlayer _player) {
		player = _player;
		gridColor = CubeGrid.Instance.playerColors[player.playerIndex];

        Vector3 origin = NewGameManager.Instance.transform.position;
        Vector2 origin2D = new Vector2(origin.x, origin.z);
        player.currentPos = origin2D + ((new Vector2(transform.position.x, transform.position.z) - origin2D).normalized * 4);

        poleEffect = new CubeEffectCircle(new CubeEffectCircleSettings(CubeEffectModes.ALL, new Vector2(goalPost.transform.position.x, goalPost.transform.position.z), gridColor, 3, 7.5f, 4));
        poleEffect.AddAnimator(new CubeEffectAnimatorPulse(CubeEffectModes.ALL, 2f, 0.75f, 1.5f));
        CubeGrid.Instance.AddEffect(poleEffect);
    }

	//Called when a ball collides with us.
	public void OnScoreEvent() {
		NewGameManager.Instance.Score(player.playerIndex);
        goalLight.FlashColor(CubeGrid.Instance.playerColors[player.playerIndex], player.playerIndex);
		SoundManager.Instance.PlaySFX(SFX.Goal);
    }

}
