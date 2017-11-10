import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {SelectModule} from 'ng2-select';

import { AppComponent } from './app.component';
import { DatasService } from "./Datas/DatasService";
import { HttpClientModule } from "@angular/common/http";
import { Ng2CompleterModule } from "ng2-completer";
import {DataComponent} from "./Datas/data.component";


@NgModule({
  declarations: [
    AppComponent,
    DataComponent
  ],
  imports: [
    SelectModule,
    BrowserModule,
    HttpClientModule,
    Ng2CompleterModule
  ],
  providers: [DatasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
