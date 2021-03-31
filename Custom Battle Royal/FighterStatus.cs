namespace Custom_Battle_Royal
{
    public class FighterStatus
    {
        public string statusEffect;
        public int statusDuration;
        public FighterStatus(string statusEffect, int statusDuration)
        {
            this.statusEffect = statusEffect;
            this.statusDuration = statusDuration;
        }
       
    }
}