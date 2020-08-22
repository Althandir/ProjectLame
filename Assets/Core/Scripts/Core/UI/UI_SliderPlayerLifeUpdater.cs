﻿using Player;

namespace GameUI.Sliders
{
    public class UI_SliderPlayerLifeUpdater : UI_SliderLifeUpdater
    {
        protected override void Start()
        {
            PlayerEntity.StaticReference.OnPlayerLifeChanged.AddListener(OnLifeChanged);

            _slider.maxValue = PlayerEntity.StaticReference.MaxHitpoints;
        }
    }
}