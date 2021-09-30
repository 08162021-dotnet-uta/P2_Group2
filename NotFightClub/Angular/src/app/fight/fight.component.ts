import { Component, OnInit } from '@angular/core';

import { Fight } from '../interfaces/fight';
import { FightService } from '../service/fight/fight.service';


@Component({
  selector: 'app-fight',
  templateUrl: './fight.component.html',
  styleUrls: ['./fight.component.css']
})
export class FightComponent implements OnInit {


  currentFightId: number = 1;

  fight: Fight | null = null;

  constructor(private fightService: FightService) { }

  ngOnInit(): void {
    this.getCurrentFight(this.currentFightId);
  }

  getCurrentFight(fightId: number) {
    return this.fightService.getCurrentFight(fightId).subscribe(fight => {
      console.log(fight);
      this.fight = fight;
    });
  }

}
