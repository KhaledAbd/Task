import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BillFormComponent } from './bill-form/bill-form.component';
import { ListBillComponent } from './list-bill/list-bill.component';

const routes: Routes = [
  {path: 'bill', component: ListBillComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
