import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './core/pages/home/home.component';

import { ToastrModule } from 'ngx-toastr';


// Shared
import { SharedModule } from './shared/shared.module';

// Services
import { SeoService } from './core/services/seo.service';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './app.routes';
import { SobreComponent } from './core/pages/sobre/sobre.component';
import { CadastreComponent } from './core/pages/cadastre/cadastre.component';
import { AcompanheComponent } from './core/pages/acompanhe/acompanhe.component';
import { PartyComponent } from './core/pages/party/party.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SobreComponent,
    CadastreComponent,
    AcompanheComponent,
    PartyComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(APP_ROUTES),
    ToastrModule.forRoot(),
    SharedModule
  ],
  providers: [ SeoService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
