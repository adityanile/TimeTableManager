import { SubjectData } from "@/app/types";
import { NextResponse } from "next/server";

export async function GET() {
  const sub: SubjectData = {
    name: "DAA Lab",
    length: 2,
    startTime: "11:00pm",
    division: "C-3",
    branch: "Comp Engg",
    teacherName: "Shivani Pandey",
    classroom: "6205",
    dayofWeek: "Monday",
  };

  console.log(sub);

  return NextResponse.json({ msg: "This is Demo api" });
}
