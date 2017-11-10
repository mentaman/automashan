import { Component, Input } from '@angular/core';
import { DatasService } from "./Datas/DatasService";
import { DataModel } from "./Datas/DataModel";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private dataService: DatasService)
  {
    this.dataService.datasChange.subscribe(
      datas => this.loaded = true
    );
  }
  list = [0];
  startId: number = 0;
  loaded: Boolean = false;

  title = 'app';

  changed(idx, newId) {
    if(this.list[idx+1] != newId)
    {
      if(idx != this.list.length - 1)
      {

        console.log("tranucate");
        this.list = this.list.slice(0, idx+1);
      }
      this.list.push(newId);
    }
  }
}
