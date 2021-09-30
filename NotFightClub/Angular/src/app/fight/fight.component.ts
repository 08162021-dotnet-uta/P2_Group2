import { Component, OnInit } from '@angular/core';

import { Fight } from '../interfaces/fight';
import { Fighter } from '../interfaces/fighter';
import { FightService } from '../service/fight/fight.service';
import { CharacterService } from '../service/character/character.service';
import { Character } from '../interfaces/character';

@Component({
  selector: 'app-fight',
  templateUrl: './fight.component.html',
  styleUrls: ['./fight.component.css']
})
export class FightComponent implements OnInit {



  fight: Fight | null = null;
  fighters: Fighter[] | null = null;

  characters: Character[] = [];

  constructor(private fightService: FightService, private characterService: CharacterService) { }

  ngOnInit(): void {
    this.getCurrentFight()

    setTimeout(() => {
      if (this.fight?.fightId != null) {
        this.getFighters(this.fight.fightId);
      }
      else {
        console.log("We got a problem.")
      }}, 1000)

    setTimeout(() => {
      if (this.fighters != null) {
        this.getCharacter(this.fighters[0].characterId, 0);
        this.getCharacter(this.fighters[1].characterId, 1);
      }
      else {
        console.log("We got another problem.");
      }
    }, 2000)
    
  }

  getCurrentFight() {
    return this.fightService.getCurrentFight().subscribe(fight => {
      console.log(fight);
      this.fight = fight;
    });
  }

  getFighters(fightId: number) {
    return this.fightService.getFighters(fightId).subscribe(fighters => {
      console.log(fighters);
      this.fighters = fighters;
    });
  }

  getCharacter(charId: number, fighter: number) {
    return this.characterService.GetCharacter(charId).subscribe(character => {
      if (fighter == 0) {
        console.log(character);
        this.characters.push(character);
      }
      else if (fighter == 1) {
        console.log(character);
        this.characters.push(character);
      }
    })
  }
}
