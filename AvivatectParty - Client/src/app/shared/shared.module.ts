import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { CardsComponent } from './components/cards/cards.component';

@NgModule({
  declarations: [NavBarComponent, CardsComponent],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [NavBarComponent, CardsComponent], 
})
export class SharedModule { }
