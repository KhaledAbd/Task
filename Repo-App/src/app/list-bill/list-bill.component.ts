import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-bill',
  templateUrl: './list-bill.component.html',
  styleUrls: ['./list-bill.component.scss']
})
export class ListBillComponent implements OnInit {

  bills: any[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  getBill(){
    this.http.get(`http://localhost:5000/api/bill/`).subscribe(
      d => {
        this.bills.push(d);
      }
    );
  }
  remove(id: number){
    this.http.delete('http://localhost:5000/api/bill/'+ id).subscribe(
      d => {
        this.bills = this.bills.filter(p => p.id == id);
      }
    )
  }

  billSet(event: any){
    this.bills.push(event);
  }

}
