public class Crimson : EnemyImpl {

    public override void Awake() {
        base.Awake();
        MusicManager.instance.Switch("Bossfight");
    }

    public override void OnDeath() {
        MusicManager.instance.Switch("World");
        LevelManager.instance.GoToNextLevel();
    }
}