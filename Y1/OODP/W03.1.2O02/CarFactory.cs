class CarFactory {
    public int ProductionLimit;

    public CarFactory(int ProductionLimit) {
        this.ProductionLimit = ProductionLimit;
    }

    public LimitedEditionCar ProduceLimitedEditionCar() {
        if (LimitedEditionCar.Counter >= ProductionLimit) {
            return null;
        }
        return new LimitedEditionCar();
    }
}
