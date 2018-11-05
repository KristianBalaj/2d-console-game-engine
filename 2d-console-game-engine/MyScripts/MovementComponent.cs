using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class MovementComponent : Component
    {
        private float movementSpeed = .2f;

        public MovementComponent(Actor parentActor) : base(parentActor)
        {
        }

        public override void OnDestroy() { }

        public override void Start()
        {
            EventManager.Subscribe<OnKeyPressedEvent>(onKeyPressed);
        }

        private void onKeyPressed(EventContext context)
        {
            var specificContext = context as OnKeyPressedEventContext;

            if (specificContext.PressedKey == ConsoleKey.LeftArrow)
            {
                this.ParentActor.Position.x -= movementSpeed;
            }

            if (specificContext.PressedKey == ConsoleKey.RightArrow)
            {
                this.ParentActor.Position.x += movementSpeed;
            }

            if (specificContext.PressedKey == ConsoleKey.UpArrow)
            {
                this.ParentActor.Position.y -= movementSpeed;
            }

            if (specificContext.PressedKey == ConsoleKey.DownArrow)
            {
                this.ParentActor.Position.y += movementSpeed;
            }
        }

        public override void Update() { }
    }
}
