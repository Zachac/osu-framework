﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using OpenTK.Graphics;

namespace osu.Framework.Testing.Drawables.StepButtons
{
    public class ToggleStepButton : StepButton
    {
        private readonly Action<bool> reloadCallback;
        private static readonly Color4 off_colour = Color4.Red;
        private static readonly Color4 on_colour = Color4.YellowGreen;

        public bool State;

        public override int RequiredRepetitions => 2;

        public ToggleStepButton(Action<bool> reloadCallback)
        {
            this.reloadCallback = reloadCallback;

            BackgroundColour = off_colour;
            Action = clickAction;
        }

        private void clickAction()
        {
            State = !State;
            BackgroundColour = State ? on_colour : off_colour;
            reloadCallback?.Invoke(State);

            if (!State)
                Success();
        }

        public override string ToString() => $"Toggle: {base.ToString()} ({(State ? "on" : "off")})";
    }
}