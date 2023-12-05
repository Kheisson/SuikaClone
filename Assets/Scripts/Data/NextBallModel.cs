namespace Data
{
    public class NextBallModel
    {
        #region --- Members ---
        
        private BallData _nextBallData;

        #endregion
        
        
        #region --- Public Methods ---
        
        public BallData GetNextBallData()
        {
            return _nextBallData;
        }

        public void SetNextBallData(BallData nextBallData)
        {
            _nextBallData = nextBallData;
        }
        
        #endregion
    }
}