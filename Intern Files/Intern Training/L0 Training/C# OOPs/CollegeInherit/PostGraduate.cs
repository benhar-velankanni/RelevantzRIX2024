class PG : Student
{
    public bool isEligible()
    {
        int avg = average();
        return avg >= 120;
    }
}