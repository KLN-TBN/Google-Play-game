using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class MyGooglePlayGamesServices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		/*PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
			// registers a callback to handle game invitations received while the game is not running.
		//	.WithInvitationDelegate(<callback method>)
			// registers a callback for turn based match notifications received while the
			// game is not running.
		//	.WithMatchDelegate(<callback method>)
			// requests the email address of the player be available.
			// Will bring up a prompt for consent.
			.RequestEmail()
			// requests a server auth code be generated so it can be passed to an
			//  associated back end server application and exchanged for an OAuth token.
			.RequestServerAuthCode(false)
			// requests an ID token be generated.  This OAuth token can be used to
			//  identify the player to other services such as Firebase.
			.RequestIdToken()
			.Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;*/

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PostHighScoreToLeaderboard(int highScore) {
		Social.ReportScore(highScore, "CgkIlN-D98YDEAIQAQ", (bool success) => {
			// handle success or failure
		});
	}

	public void PostLevelNumberToLeaderboard(int level) {
		Social.ReportScore(level, "CgkIlN-D98YDEAIQAw", (bool success) => {
			// handle success or failure
		});
	}

	public void UnlockAchievement(string id) {
		Social.ReportProgress(id, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void ShowLeaderboard() {
		Social.ShowLeaderboardUI();
	}

	public void ShowAchievements() {
		Social.ShowAchievementsUI();
	}
}