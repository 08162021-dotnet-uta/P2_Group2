using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.Models;
using NotFightClub_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotFightClub_Logic.Mappers
{
  public class FightMapper : IMapper<Fight, ViewFight>
  {
    public ViewFight ModelToViewModel(Fight obj)
    {
      ViewFight viewFight = new ViewFight();
      viewFight.FightId = obj.FightId;
      viewFight.Winner = obj.Winner;
      viewFight.Loser = obj.Loser;
      viewFight.Date = obj.Date;
      viewFight.Result = obj.Result;
      viewFight.Location = obj.Location;
      viewFight.Weather = obj.Weather;

      return viewFight;
    }

    public Fight ViewModelToModel(ViewFight obj)
    {
      Fight fight = new Fight();
      fight.FightId = obj.FightId;
      fight.Winner = obj.Winner;
      fight.Loser = obj.Loser;
      fight.Date = obj.Date;
      fight.Result = obj.Result;
      fight.Location = obj.Location;
      fight.Weather = obj.Weather;

      return fight;
    }

    public List<ViewFight> ModelToViewModel(List<Fight> obj)
    {
      List<ViewFight> fights = new List<ViewFight>();
      for (int i = 0; i < obj.Count; i++)
      {
        ViewFight f = new ViewFight();
        f.FightId = obj[i].FightId;
        f.Winner = obj[i].Winner;
        f.Loser = obj[i].Loser;
        f.Date = obj[i].Date;
        f.Result = obj[i].Result;
        f.Location = obj[i].Location;
        f.Weather = obj[i].Weather;
        fights.Add(f);
      }

      return fights;
    }


    public List<Fight> ViewModelToModel(List<ViewFight> obj)
    {
      List<Fight> fights = new List<Fight>(obj.Count);
      for (int i = 0; i < obj.Count; i++)
      {
        fights[i].FightId = obj[i].FightId;
        fights[i].Winner = obj[i].Winner;
        fights[i].Loser = obj[i].Loser;
        fights[i].Date = obj[i].Date;
        fights[i].Result = obj[i].Result;
        fights[i].Location = obj[i].Location;
        fights[i].Weather = obj[i].Weather;
      }

      return fights;
    }
  }
}
