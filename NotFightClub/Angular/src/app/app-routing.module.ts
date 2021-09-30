import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { ChatComponent } from './chat/chat.component';
import { EditProfileComponent } from './user/edit-profile/edit-profile.component';
import { StoreComponent } from './store/store.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { CharacterComponent } from './character/character/character.component';
import { HomeComponent } from './home/home.component';

import { FightComponent } from './fight/fight.component';






const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'chat', component: ChatComponent },
  { path: 'store', component: StoreComponent },
  { path: 'edit-profile/:userId', component: EditProfileComponent, canActivate:[AuthGuard] }, 
  { path: 'character', component: CharacterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'users', component: UserListComponent },
  { path: 'users/:userId', component: UserProfileComponent, canActivate:[AuthGuard] },
  { path: 'fight/:fightId', component: FightComponent }
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
