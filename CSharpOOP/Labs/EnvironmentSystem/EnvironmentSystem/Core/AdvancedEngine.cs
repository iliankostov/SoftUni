namespace EnvironmentSystem.Core
{
    using System;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models;

    public class AdvancedEngine : Engine
    {
        private IController controller;
        private bool isPaused;

        public AdvancedEngine(IController controller)
            : base()
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!this.isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            base.Insert(obj);
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += (sender, args) =>
            {
                this.isPaused = !this.isPaused;
            };
        }
    }
}
