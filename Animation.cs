using System;
using System.Collections.Generic;
using System.Drawing; // For Image
using System.Linq;
using PixelWonders.Properties; // For accessing Resources

namespace PixelWonders
{
    internal static class Animation
    {
        private static readonly Random _random = new Random();
        // Static dictionary containing lists of images from resources
        public static readonly Dictionary<string, List<Image>> AnimationsDict = new Dictionary<string, List<Image>>
        {
            {
                "turtle_orange", new List<Image>
                {
                    Resources.orange_run_8fps,
                    Resources.orange_swipe_8fps,
                    Resources.orange_walk_8fps,
                    Resources.orange_walk_fast_8fps,
                    Resources.orange_with_ball_8fps,
                    Resources.orange_idle_8fps,
                    Resources.orange_lie_8fps
                }
            },
            { 
                "turtle_green", new List<Image>
                {

                    Resources.green_idle_8fps,
                    Resources.green_run_8fps,
                    Resources.green_swipe_8fps,
                    Resources.green_walk_8fps,
                    Resources.green_walk_fast_8fps,
                    Resources.green_with_ball_8fps,
                    Resources.green_lie_8fps
                }
            },
            {
                "snail_brown", new List<Image>{
                   Resources.brown_idle_8fps,
                   Resources.brown_run_8fps,
                   Resources.brown_swipe_8fps,
                   Resources.brown_walk_8fps,
                   Resources.brown_walk_fast_8fps,
                   Resources.brown_with_ball_8fps

                }
            },
            {
                "snake_green", new List<Image>{
                   Resources.green_idle_8fps1,
                   Resources.green_run_8fps1,
                   Resources.green_swipe_8fps1,
                   Resources.green_walk_8fps1,
                   Resources.green_walk_fast_8fps1,
                   Resources.green_with_ball_8fps1
                }
            },
            {
                "totoro_gray", new List<Image>{
                   Resources.gray_fall_from_grab_8fps,
                   Resources.gray_idle_8fps,
                   Resources.gray_jump_8fps,
                   Resources.gray_land_8fps,
                   Resources.gray_lie_8fps,
                   Resources.gray_run_8fps,
                   Resources.gray_swipe_8fps,
                   Resources.gray_walk_8fps,
                   Resources.gray_wallclimb_8fps,
                   Resources.gray_wallgrab_8fps,
                   Resources.gray_with_ball_8fps
                }
            },
            {
                "rat_brown", new List<Image>{
                   Resources.brown_idle_8fps1,
                   Resources.brown_run_8fps1,
                   Resources.brown_swipe_8fps1,
                   Resources.brown_walk_8fps1,
                   Resources.brown_walk_fast_8fps1,
                   Resources.brown_with_ball_8fps1
                }
            },
            {
                "rat_gray", new List<Image>{
                   Resources.gray_idle_8fps1,
                   Resources.gray_run_8fps1,
                   Resources.gray_swipe_8fps1,
                   Resources.gray_walk_8fps1,
                   Resources.gray_walk_fast_8fps1,
                   Resources.gray_with_ball_8fps1
                }
            },
            {
                "rat_white", new List<Image>{
                   Resources.white_idle_8fps,
                   Resources.white_run_8fps,
                   Resources.white_swipe_8fps,
                   Resources.white_walk_8fps,
                   Resources.white_walk_fast_8fps,
                   Resources.white_with_ball_8fps
                }
            },
            {
                "rocky_gray", new List<Image>{
                   Resources.gray_idle_8fps2,
                   Resources.gray_run_8fps2,
                   Resources.gray_swipe_8fps2,
                   Resources.gray_walk_8fps2,
                   Resources.gray_walk_fast_8fps2
                }
            },
            {
                "rubber-duck", new List<Image>{
                   Resources.yellow_idle_8fps,
                   Resources.yellow_run_8fps,
                   Resources.yellow_swipe_8fps,
                   Resources.yellow_walk_8fps,
                   Resources.yellow_walk_fast_8fps,
                   Resources.yellow_with_ball_8fps
                }
            },
            {
                "mod", new List<Image>{
                   Resources.purple_idle_8fps,
                   Resources.purple_run_8fps,
                   Resources.purple_swipe_8fps,
                   Resources.purple_walk_8fps,
                   Resources.purple_walk_fast_8fps,
                   Resources.purple_with_ball_8fps
                }
            },
            {
                "panda_black", new List<Image>{
                   Resources.black_idle_8fps,
                   Resources.black_lie_8fps,
                   Resources.black_run_8fps,
                   Resources.black_swipe_8fps,
                   Resources.black_walk_8fps,
                   Resources.black_walk_fast_8fps,
                   Resources.black_with_ball_8fps,
                }
            },
            {
                "panda_brown", new List<Image>{
                    Resources.brown_idle_8fps2,
                    Resources.brown_lie_8fps,
                    Resources.brown_run_8fps2,
                    Resources.brown_swipe_8fps2,
                    Resources.brown_walk_8fps2,
                    Resources.brown_walk_fast_8fps2,
                    Resources.brown_with_ball_8fps2
                }
            },
            //{
            //    "horse", new List<Image>{
            //        // later cuz too many horses
            //    }
            //},
            //{
            //    "dog", new List<Image>{
            //       // later cuz too many dogs
            //    }
            //},
            {
                "fox_red", new List<Image>{
                   Resources.red_idle_8fps,
                   Resources.red_lie_8fps,
                   Resources.red_run_8fps,
                   Resources.red_walk_8fps,
                   Resources.red_walk_fast_8fps,
                   Resources.red_with_ball_8fps
                }
            }, 
            {
                "fox_white", new List<Image>{
                   Resources.white_idle_8fps3,
                   Resources.white_lie_8fps1,
                   Resources.white_run_8fps3,
                   Resources.white_swipe_8fps3,
                   Resources.white_walk_8fps3,
                   Resources.white_walk_fast_8fps3,
                   Resources.white_with_ball_8fps
                }
            },
            {
                "deno", new List<Image>{
                   Resources.green_idle_8fps2,
                   Resources.green_run_8fps2,
                   Resources.green_swipe_8fps2,
                   Resources.green_walk_8fps2,
                   Resources.green_walk_fast_8fps,
                   Resources.green_with_ball_8fps2
                }
            },
            {
                "cockatiel", new List<Image>{
                   Resources.gray_idle_8fps3,
                   Resources.gray_run_8fps3,
                   Resources.gray_swipe_8fps3,
                   Resources.gray_walk_8fps3,
                   Resources.gray_walk_fast_8fps2,
                   Resources.gray_with_ball_8fps2

                }
            },
            {
                "crab", new List<Image>{
                   Resources.red_idle_8fps4,
                   Resources.red_run_8fps2,
                   Resources.red_swipe_8fps2,
                   Resources.red_walk_8fps2,
                   Resources.red_walk_fast_8fps2,
                   Resources.red_with_ball_8fps2
                }
            },
            {
                "chicken", new List<Image>{
                   Resources.white_idle_8fps4,
                   Resources.white_run_8fps4,
                   Resources.white_swipe_8fps4,
                   Resources.white_walk_8fps4,
                   Resources.white_walk_fast_8fps4,
                   Resources.white_with_ball_8fps4

                }
            }
        };
    public static readonly List<Image> WalkAnimations = new List<Image>
    {
        AnimationsDict["turtle_orange"][2],  // orange_walk_8fps
        AnimationsDict["turtle_orange"][3],  // orange_walk_fast_8fps
        AnimationsDict["turtle_green"][3],   // green_walk_8fps
        AnimationsDict["turtle_green"][4],   // green_walk_fast_8fps
        AnimationsDict["snail_brown"][3],    // brown_walk_8fps
        AnimationsDict["snail_brown"][4],    // brown_walk_fast_8fps
        AnimationsDict["snake_green"][3],    // green_walk_8fps1
        AnimationsDict["snake_green"][4],    // green_walk_fast_8fps1
        AnimationsDict["totoro_gray"][7],    // gray_walk_8fps
        AnimationsDict["rat_brown"][3],      // brown_walk_8fps1
        AnimationsDict["rat_brown"][4],      // brown_walk_fast_8fps1
        AnimationsDict["rat_gray"][3],       // gray_walk_8fps1
        AnimationsDict["rat_gray"][4],       // gray_walk_fast_8fps1
        AnimationsDict["rat_white"][3],      // white_walk_8fps
        AnimationsDict["rat_white"][4],      // white_walk_fast_8fps
        AnimationsDict["rocky_gray"][3],     // gray_walk_8fps2
        AnimationsDict["rocky_gray"][4],     // gray_walk_fast_8fps2
        AnimationsDict["rubber-duck"][3],    // yellow_walk_8fps
        AnimationsDict["rubber-duck"][4],    // yellow_walk_fast_8fps
        AnimationsDict["mod"][3],            // purple_walk_8fps
        AnimationsDict["mod"][4],            // purple_walk_fast_8fps
        AnimationsDict["panda_black"][4],    // black_walk_8fps
        AnimationsDict["panda_black"][5],    // black_walk_fast_8fps
        AnimationsDict["panda_brown"][4],    // brown_walk_8fps2
        AnimationsDict["panda_brown"][5],    // brown_walk_fast_8fps2
        AnimationsDict["fox_red"][3],        // red_walk_8fps
        AnimationsDict["fox_red"][4],        // red_walk_fast_8fps
        AnimationsDict["fox_white"][4],      // white_walk_8fps3
        AnimationsDict["fox_white"][5],      // white_walk_fast_8fps3
        AnimationsDict["deno"][3],           // green_walk_8fps2
        AnimationsDict["deno"][4],           // green_walk_fast_8fps
        AnimationsDict["cockatiel"][3],      // gray_walk_8fps3
        AnimationsDict["cockatiel"][4],      // gray_walk_fast_8fps2
        AnimationsDict["crab"][3],           // red_walk_8fps2
        AnimationsDict["crab"][4],           // red_walk_fast_8fps2
        AnimationsDict["chicken"][3],        // white_walk_8fps4
        AnimationsDict["chicken"][4]        // white_walk_fast_8fps4
    };

        public static string GetRandomAnimalKey()
        {
            int index = _random.Next(AnimationsDict.Count);
            var pair = AnimationsDict.ElementAt(index);
            return pair.Key;
        }
        public static List<Image> GetImages(string animalKey)
        {
            AnimationsDict.TryGetValue(animalKey, out var images);
            return images;
        }

    }
}
