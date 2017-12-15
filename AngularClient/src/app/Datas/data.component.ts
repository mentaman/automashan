import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { DatasService } from "./DatasService";
import { DataModel } from "./DataModel";

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
})
export class DataComponent implements OnInit {
    @Input() id: number;
    @Output()
    change: EventEmitter<any> = new EventEmitter();
    public items: Array<any> = [];
    constructor(private dataService: DatasService)
    {

    }
    ngOnInit() {
      const data = this.dataService.datas[this.id];
      for(const id of data.NextIds)
      {
        const current = this.dataService.datas[id];
        this.items.push({id: current.Id, text: current.Name+current.ParameterTypes[0]});
      }
    }


}
