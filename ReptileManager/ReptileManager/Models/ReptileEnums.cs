using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{
 
        public enum Gender { Male, Female, Unknow }
        public enum WeightProgress { PlusWeight, MinusWeight }
        public enum FeedingType
        {
            [Display(Name = "African furred rats")]
            AfricanFurredRats,
            AFT,
            [Display(Name = "Brained pinky")]
            BrainedPinky,
            Bugs, Butterworms,
            [Display(Name = "Chicks frozen")]
            ChicksFrozen,
            [Display(Name = "Chicks live")]
            ChicksLive,
            [Display(Name = "Chicks prekill")]
            ChicksPreKill,
            Crickets,
            Dubias,
            Earthworms,
            [Display(Name = "Frozen Anoles")]
            FrozenAnoles,
            Fruit, Gerbils, Greens,
            [Display(Name = "Guinea pig frozen")]
            GuineaPigFrozen,
            [Display(Name = "Guinea pig live")]
            GuineaPigLive,
            [Display(Name = "Guinea pig prekill")]
            GuineaPrekill,
            Hamster,
            Hornworms,
            [Display(Name = "Live Anoles")]
            LiveAnoles,
            Mealworms,
            [Display(Name = "Meat cooked")]
            MeatCooked,
            [Display(Name = "Meat raw")]
            MeatRaw,
            [Display(Name = "Mice frozen")]
            MiceFrozen,
            [Display(Name = "Mice live")]
            MiceLive,
            [Display(Name = "Mice prekill")]
            MicePrekill,
            MPR,
            [Display(Name = "Phonenix worms")]
            Phonenixworms,
            Piglets,
            [Display(Name = "Rabbit frozen")]
            RabbitsFrozen,
            [Display(Name = "Rabbit live")]
            RabbitsLive,
            [Display(Name = "Rabbit prekill")]
            RabbitsPrekill,
            [Display(Name = "Rat frozen")]
            RatFrozen,
            [Display(Name = "Rat live")]
            RatLive,
            [Display(Name = "Rat prekill")]
            RatPrekill,
            [Display(Name = "Refused feed")]
            RefusedFeed,
            Regurgitation,
            Repashy,
            Superworms,
            Veggies
        }
        public enum CleaningType
        {
            [Display(Name = "Deep clean")]
            DeepClean,
            [Display(Name = "Fresh water")]
            FreshWater,
            [Display(Name = "Spot clean")]
            SpotClean
        }
        public enum ShedType
        {
            [Display(Name = "In shed")]
            Inshed,
            [Display(Name = "Pre shed")]
            Preshed,
            Shed,
            [Display(Name = "Shed out")]
            Shedout,
            [Display(Name = "Bad shed")]
            Badshed
        }
        public enum FoodSize
        {
            Pinkie,
            Crawler,
            Fuzzie,
            Weaned,
            Pup,
            Jumbo,
            S,
            M,
            L,
            XL

        }
        public enum BreedingStage
        {
            Follicles,
            Ovulation,
            [Display(Name = "Pre Shed")]
            PreShed,
            [Display(Name = "Sperm Plugs")]
            SpermPlugs

        }
        public enum CategoryNote
        {
            Standard,
            Medical,
            [Display(Name = "Follow up")]
            Followup
        }
        public enum Event { Introduction, Courting, Breeding, Seperated }
    

  
}