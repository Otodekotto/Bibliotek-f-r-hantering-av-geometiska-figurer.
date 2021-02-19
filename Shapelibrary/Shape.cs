using System;
using System.Numerics;

namespace Shapelibrary
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
      
        public static float RandomFloat()
        {
            Random rnd = new Random();
            float rndFloat = rnd.Next(10, 100) * .1f;
            return rndFloat;
        }

        public static Shape GenerateShape()
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 7);

            switch (rndNum)
            {
                case 0:
                    return new Circle(new Vector2(RandomFloat(), RandomFloat()), RandomFloat());
                    break;
                case 1:
                    return new Rectangle(new Vector2(RandomFloat(), RandomFloat()), RandomFloat());
                    break;
                case 2:
                    return new Rectangle(new Vector2(RandomFloat(), RandomFloat()), new Vector2(RandomFloat(), RandomFloat()));
                    break;
                case 3:
                    return new Triangle(new Vector2(RandomFloat(), RandomFloat()), new Vector2(RandomFloat(), RandomFloat()), new Vector2(RandomFloat(), RandomFloat()));
                    break;
                case 4:
                    return new Cuboid(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), (new Vector3(RandomFloat(), RandomFloat(), RandomFloat())));
                    break;
                case 5:
                    return new Cuboid(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), RandomFloat());
                    break;
                default:
                    return new Sphere(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), RandomFloat());
                    break;

            }

        }

        public static Shape GenerateShape2(Vector3 center)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 7);

            switch (rndNum)
            {
                case 0:
                    return new Circle(new Vector2(center.X, center.Y), RandomFloat());
                    break;
                case 1:
                    return new Rectangle(new Vector2(center.X, center.Y), RandomFloat());
                    break;
                case 2:
                    return new Rectangle(new Vector2(center.X, center.Y), new Vector2(RandomFloat(), RandomFloat()));
                    break;
                case 3:
                    float position1x = RandomFloat();
                    float position1y = RandomFloat();
                    float position2x = RandomFloat();
                    float position2y = RandomFloat();
                    return new Triangle(new Vector2(position1x, position1y), new Vector2(position2x, position2y), new Vector2((center.X * 3) - position1x - position2x, (center.Y * 3) - position1y - position2y));
                case 4:
                    return new Cuboid(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), (new Vector3(RandomFloat(), RandomFloat(), RandomFloat())));
                    break;
                case 5:
                    return new Cuboid(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), RandomFloat());
                    break;
                default:
                    return new Sphere(new Vector3(RandomFloat(), RandomFloat(), RandomFloat()), RandomFloat());
                    break;
            }


        }

    }
}
