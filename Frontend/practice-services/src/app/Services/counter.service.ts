export class CounterService{
    inactivenumbers: number = 0;
    activenumbers: number = 0;

    pressinactivebtn(){
        this.inactivenumbers++;
        console.log("click to inactive button " + this.inactivenumbers);

    }
    pressactivebtn(){
        this.activenumbers++;
        console.log("click to active button " +this.activenumbers);

    }

}