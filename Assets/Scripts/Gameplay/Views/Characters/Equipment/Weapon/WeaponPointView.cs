﻿using MVP;
using UnityEngine;

namespace Gameplay
{
    public class WeaponPointView : View<WeaponPointPresenter>
    {
        [SerializeField] private EquipmentPointPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}