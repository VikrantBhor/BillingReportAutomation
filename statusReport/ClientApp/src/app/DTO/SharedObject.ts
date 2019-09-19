export class SharedObject {
  constructor(
    public reportId: string,
    public projectId: string,
    public projectName: string,
    public clientName: string,    
    public reportType: string,
    public type: string,
    public reportDate: string,
    public reportStartDate: string,
    public reportEndDate: string,
    public createdByEmail: string,
    public createdBy: string,
    public clientId: string
  ) {
  }


}
