import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {Employee} from './employee';
import {EmployeeDetail} from './employeedetail';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(
  private http: HttpClient) { }

  private employeeApiUrl = 'http://localhost:55435/api/Employees';

  public getEmployees(): Observable<Employee[]> {
      return this.http.get<Employee[]>(this.employeeApiUrl);
  }
  public getSingleEmployee(employeeId): Observable<EmployeeDetail[]> {
        return this.http.get<EmployeeDetail[]>(this.employeeApiUrl.concat("/" + employeeId));
  }
}
