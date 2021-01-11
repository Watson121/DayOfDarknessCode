using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPool : MonoBehaviour
{

    #region ZOMBIES

    //UPPERCASE
    public string[] Zombie_Word_Pool = {"Zombie", "Death", "Undead", "Walking_Dead", "Dead",
                                            "Coming_from_the_ground", "Evil_Dead", "Groovy", "Gunshot", "Watch_out", "Brains", "Evil_Eye",
                                        "Living_Dead", "Boomstick", "Shotgun", "In_the_face",
                                        "Blown_away", "Saving_the_World", "Carpe_Diem", "Risen", "Terrifying",
                                        "Nice_shot", "Headshot", "Kicking_arse", "Fuck_you_zombie"};

    //LOWERCASE
    public string[] Zombie_Word_Pool_LC = {"zombie", "death", "undead", "walking_dead", "dead",
                                            "coming_from_the_ground", "evil_dead", "groovy", "gunshot", "watch_out", "brains", "evil_eye",
                                        "living_dead", "boomstick", "shotgun", "in_the_face",
                                        "blown_away", "saving_the_World", "carpe_diem", "risen", "terrifying",
                                        "nice_shot", "deadshot", "kicking_arse", "fuck_you_zombie"};

    #endregion


    #region SKELETON

    public string[] Skeleton_Word_Pool = {"Skeleton", "Skelly", "Bones", "Bag_of_Bones", "Skull",
                                            "Spine", "Pelvis", "Hands", "Day_of_Reckoning", "Scary", "Gunshot", "Dodge_this", "Demon",
                                            "Ghoul", "Dirty_Bastards", "Demonic"};

    public string[] Skeleton_Word_Pool_LC = {"skeleton", "skelly", "bones", "bag_of_bones", "skull",
                                            "spine", "pelvis", "hands", "day_of_reckoning", "scary", "gunshot", "dodge_this", "demon",
                                            "ghoul", "dirty_bastards", "demonic"};


    #endregion

    public string[] Ghost_Word_Pool = {"Ghosty", "Ghost", "Ghoul", "Transparent_Ghost", "Ecoplasm", "Was_alive_at_some_point", "Scary", "Woman_in_Black"};

    public string[] Projectile_Word_Pool = {"Gunshot", "Missle", "Energy Ball", "Watch out!",
                                            "Dodge this!", "Missed shot"};

    public string[] Final_Boss_Word_Pool = {"Poke in the eye", "Meat Demon", "Demon", "Evil Eye",
                                            "Day_of_Reckoning"};

    public string[] Powerups_Word_Pool = {"Health Pick Up", "Slow Down Time", "2x Points"};

    public string[] PlayerInteraction_Word_Pool = {"Open Door", "Kick Down Door!", "Torch", "Continue"};

}
