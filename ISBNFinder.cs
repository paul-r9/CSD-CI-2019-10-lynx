using BookInfoProvider;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {
            
            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        public int IsValidIsbn10(string isbnNumber10)
        {
            int sum = 0;

            for (int i = 0; i < isbnNumber10.Length-1; i++)
            {
                int num = int.Parse(isbnNumber10[i].ToString());

                sum += num *(i+1);
            }

            int lastDigit = sum % 11;

            return lastDigit;
        }
    }
}