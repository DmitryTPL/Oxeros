﻿namespace Gameplay
{
    public class NoticeMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.Notice;
        public override MobTransition Transition => MobTransition.Notice;
    }
}