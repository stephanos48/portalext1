export interface SoPlan {
    soPlanId: number;
    orderDateTime: Date;
    customer: string;
    customerOrderNo: string;
    customerOrderLine: string;
    soNumber: string;
    woNumber: string;
    customerPn: string;
    extremePn: string;
    partDescription: string;
    orderQty: number;
    shipQty: number;
    invNumber: string;
    requestedDateTime: Date;
    promiseDateTime: Date;
    shipDateTime: Date;
    shipPlanStatus: string;
    hotShipment: string;
    carrier: string;
    trackingInfo: string;
    shipToAddress: string;
    notes: string;

}