import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-bill-form',
  templateUrl: './bill-form.component.html',
  styleUrls: ['./bill-form.component.scss']
})
export class BillFormComponent implements OnInit {

  billForm: FormGroup = new FormGroup (
    {
      clientName : new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required])
    }
  );

  @Output() bill = new EventEmitter<any>();

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  Save(){
    console.log(this.billForm.value);
    if(this.billForm.valid) {
      let returnForm:any = {
        clienName: this.billForm.get('clientName')?.value,
        billItemsDtos: [
          {
            price: this.billForm.get('price')?.value,
            itemFormDtos: {
              name: this.billForm.get('name')?.value
            }
          }
        ]
      };
      console.log(returnForm);
      this.http.post<any>('https://localhost:5001/api/bill/',returnForm).subscribe(
        d => {

          console.log(d);
        }
      )
    }
  }

}
