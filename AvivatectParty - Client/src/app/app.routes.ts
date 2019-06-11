import { Routes } from '@angular/router';
import { HomeComponent } from './core/pages/home/home.component';
import { SobreComponent } from './core/pages/sobre/sobre.component';
import { CadastreComponent } from './core/pages/cadastre/cadastre.component';
import { AcompanheComponent } from './core/pages/acompanhe/acompanhe.component';
import { PartyComponent } from './core/pages/party/party.component';

export const APP_ROUTES: Routes = [
    {path: '', component: HomeComponent},
    {path: 'sobre', component: SobreComponent},
    {path: 'cadastre', component: CadastreComponent},
    {path: 'acompanhe', component: AcompanheComponent},
    {path: 'party', component: PartyComponent}
]