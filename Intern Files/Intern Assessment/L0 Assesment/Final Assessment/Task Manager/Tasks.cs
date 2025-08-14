struct Task
{
    public int ID;
    public string Description;
    public bool Status;

    public Task(int id, string description)
    {
        this.ID = id;
        this.Description = description;
        this.Status = false;
    }
};

