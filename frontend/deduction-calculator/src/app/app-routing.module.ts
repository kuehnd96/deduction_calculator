import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDeductionComponent  } from './employee-deduction/employee-deduction.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeDeductionComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
