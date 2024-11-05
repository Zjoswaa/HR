static class Library {
    public static void Checkout(List<IBorrow> BorrowableItems) {
        foreach (IBorrow BorrowableItem in BorrowableItems) {
            BorrowableItem.Borrow();
        }
    }
}
